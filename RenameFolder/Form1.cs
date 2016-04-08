using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using Dropbox.Api;

namespace RenameFolder
{
    public partial class Form1 : Form
    {
        DfBTeam gbl_TeamObject;

        [DataContract]
        class FolderListing
        {
            //folder listing:
            [DataMember]
            public string size { get; set; }
            [DataMember]
            public string hash { get; set; }
            [DataMember]
            public double bytes { get; set; }
            [DataMember]
            public string thumb_exists { get; set; }
            [DataMember]
            public string rev { get; set; }
            [DataMember]
            public string modified { get; set; }
            [DataMember]
            public string path { get; set; }
            [DataMember]
            public string is_dir { get; set; }
            [DataMember]
            public string icon { get; set; }
            [DataMember]
            public string root { get; set; }
            [DataMember]
            public string revision { get; set; }

            //not in sample
            [DataMember]
            public string is_deleted { get; set; }
            [DataMember]
            public string photo_info { get; set; }
            [DataMember]
            public string video_info { get; set; }
            [DataMember]
            public string client_mtime { get; set; }
            [DataMember]
            public List<Shared_Folder> shared_folder { get; set; }
            [DataMember]
            public string read_only { get; set; }
            [DataMember]
            public string parent_shared_folder_id { get; set; }
            [DataMember]
            public string modifier { get; set; }
            [DataMember]
            public List<FolderContent> contents { get; set; }
        }

        [DataContract]
        class Shared_Folder
        {
            //permissions:
            [DataMember]
            public string shared_folder_id { get; set; }
        }

        [DataContract]
        class FolderContent
        {
            [DataMember]
            public string size { get; set; }
            [DataMember]
            public string rev { get; set; }
            [DataMember]
            public double bytes { get; set; }
            [DataMember]
            public string thumb_exists { get; set; }
            [DataMember]
            public string modified { get; set; }
            [DataMember]
            public string client_mtime { get; set; }
            [DataMember]
            public string path { get; set; }
            [DataMember]
            public string photo_info { get; set; }
            [DataMember]
            public string is_dir { get; set; }
            [DataMember]
            public string icon { get; set; }
            [DataMember]
            public string root { get; set; }
            [DataMember]
            public string mime_type { get; set; }
            [DataMember]
            public string revision { get; set; }
        }
        [DataContract]
        class BasicTeamInformation
        {
            //folder listing:
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public string team_id { get; set; }
            [DataMember]
            public int num_licenced_users { get; set; }
            [DataMember]
            public int num_provisioned_users { get; set; }
        }

        [DataContract]
        class Profile
        {
            //profile:
            [DataMember]
            public string given_name { get; set; }
            [DataMember]
            public string surname { get; set; }
            [DataMember]
            public string status { get; set; }
            [DataMember]
            public string member_id { get; set; }
            [DataMember]
            public string email { get; set; }
            [DataMember]
            public string external_id { get; set; }
            [DataMember]
            public List<string> groups { get; set; }
        }

        [DataContract]
        class Permissions
        {
            //permissions:
            [DataMember]
            public bool is_admin { get; set; }
        }

        [DataContract]
        class Member
        //member is made up of profile and permissions components
        {
            [DataMember]
            public Profile profile { get; set; }
            [DataMember]
            public Permissions permissions { get; set; }
        }

        [DataContract]
        class DfBTeam
        {
            //team is made up of members and has a cursor and has_more attribute
            [DataMember]
            public List<Member> members { get; set; }
            [DataMember]
            public string cursor { get; set; }
            [DataMember]
            public bool has_more { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set the disconnected picture
            pictureBoxStatus.Image = imageList1.Images[1];

            //hide the stuff we dont need yet
            label2.Visible = false;
            comboUserList.Visible = false;
            btnListMemberFolders.Visible = false;
            comboFolderList.Visible = false;
            txtFolderList.Visible = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;

            //obtain basic api information
            BasicTeamInformation teamInformation = dfbBasicTeamInfo();
            //obtain team information
            DfBTeam dfbTeam = dfb_members_list();

            //if we connect to the api successfully:
            if (teamInformation.num_licenced_users >= 0)
            {
                //update the connected Image
                pictureBoxStatus.Image = imageList1.Images[0];

                //populate the global object for use throughout the app.
                gbl_TeamObject = dfbTeam;

                //disable the button and the input box
                txtToken.ReadOnly = true;
                btnConnect.Visible = false;

                //reveal the user list
                label2.Visible = true;
                comboUserList.Visible = true;
                btnListMemberFolders.Visible = true;

                //populate the combo box
                foreach (Member member in gbl_TeamObject.members)
                    comboUserList.Items.Add(member.profile.email);
            }

            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }

        private BasicTeamInformation dfbBasicTeamInfo()
        {
            String page = "https://api.dropbox.com/1/team/get_info";
            WebRequest request = WebRequest.Create(page);

            request.Method = "POST";
            request.ContentType = "application/json";
            String authheader = "Authorization:Bearer " + txtToken.Text;
            request.Headers.Add(authheader);

            // Create POST data and convert it to a byte array.
            string postData = "{}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream ds = request.GetRequestStream();

            // Write the data to the request stream.
            ds.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            ds.Close();

            // Get the response.
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                // Read the content. 
                string responseFromServer = reader.ReadToEnd();

                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();

                //serialise the json so we can send back a BasicTeamInformation object
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BasicTeamInformation));
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseFromServer));
                BasicTeamInformation teamObj = (BasicTeamInformation)ser.ReadObject(stream);

                return teamObj;
            }

            catch (WebException error)
            {
                BasicTeamInformation failedObj = new BasicTeamInformation();
                failedObj.name = error.Message;
                failedObj.num_licenced_users = -1;
                failedObj.num_provisioned_users = -1;
                return failedObj;
            }
        }

        private DfBTeam dfb_members_list()
        {
            String page = "https://api.dropbox.com/1/team/members/list";
            WebRequest request = WebRequest.Create(page);

            request.Method = "POST";
            request.ContentType = "application/json";
            String authheader = "Authorization:Bearer " + txtToken.Text;
            request.Headers.Add(authheader);

            // Create POST data and convert it to a byte array.
            string postData = "{}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream ds = request.GetRequestStream();

            // Write the data to the request stream.
            ds.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            ds.Close();

            // Get the response.
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                // Read the content. 
                string responseFromServer = reader.ReadToEnd();

                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();

                //serialise the json so we can send back a BasicTeamInformation object
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DfBTeam));
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseFromServer));
                DfBTeam teamObj = (DfBTeam)ser.ReadObject(stream);

                return teamObj;
            }

            catch (WebException error)
            {
                DfBTeam failedObj = new DfBTeam();
                failedObj.cursor = error.Message;
                return failedObj;
            }

        }

        private void btnListMemberFolders_Click(object sender, EventArgs e)
        {

            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;

            FolderListing rootFolderListing = Get_listing("/", txtToken.Text, gbl_TeamObject.members[5].profile.member_id);
            foreach (FolderContent fc in rootFolderListing.contents)
            {
                //if (fc.is_dir)
                comboFolderList.Items.Add(fc.path);
            }

            //update the ui
            comboFolderList.Visible = true;
            txtFolderList.Visible = true;
            btnListMemberFolders.Visible = false;
            comboUserList.Visible = false;
            txtTargetAccount.Visible = true;
            txtTargetAccount.ReadOnly = true;

            

            // Set cursor as hourglass
            Cursor.Current = Cursors.Default;

        }

        private void comboUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTargetAccount.Text = comboUserList.Text;
        }

        private FolderListing Get_listing(string folderpath, string dfb_token, string dfb_member_id)
        {

            if (folderpath == null)
            {
                Console.WriteLine("Empty path");
            }

            else
            {
                string uri = "https://api.dropbox.com/1/metadata/auto" + folderpath; // +"?list=false";
                WebRequest request = WebRequest.Create(uri);

                request.Method = "GET";
                request.ContentType = "application/json";
                String authheader = "Authorization:Bearer " + dfb_token;
                request.Headers.Add(authheader);
                request.Headers.Add("X-Dropbox-Perform-As-Team-Member:" + dfb_member_id);

                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    // Get the stream containing content returned by the server.
                    Stream dataStream = response.GetResponseStream();

                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);

                    // Read the content. 
                    string responseFromServer = reader.ReadToEnd();

                    //serialize the json
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FolderListing));
                    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseFromServer));
                    try
                    {
                        var obj = (FolderListing)ser.ReadObject(stream);

                        // Cleanup the streams and the response.
                        reader.Close();
                        dataStream.Close();
                        response.Close();

                        return obj;
                    }
                    catch
                    {
                        FolderListing failListing = new FolderListing();
                        failListing.bytes = -2;
                        return failListing;
                    }

                }

                catch (WebException error)
                {
                    Console.WriteLine(error);
                }

            }
            FolderListing brokenListing = new FolderListing();
            brokenListing.bytes = -1;
            return brokenListing;
        } //end of get_listing


    }
}
