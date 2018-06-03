using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _5051.Models;
namespace _5051.Backend
{
    /// <summary>
    /// Backend Mock DataSource for Avatars, to manage them
    /// </summary>
    public class AvatarDataSourceMock : IAvatarInterface
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile AvatarDataSourceMock instance;
        private static object syncRoot = new Object();

        private AvatarDataSourceMock() { }

        public static AvatarDataSourceMock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AvatarDataSourceMock();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The Avatar List
        /// </summary>
        private List<AvatarModel> avatarList = new List<AvatarModel>();

        /// <summary>
        /// Makes a new Avatar
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Avatar Passed In</returns>
        public AvatarModel Create(AvatarModel data)
        {
            avatarList.Add(data);
            return data;
        }

        /// <summary>
        /// Return the data for the id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Null or valid data</returns>
        public AvatarModel Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var myReturn = avatarList.Find(n => n.Id == id);
            return myReturn;
        }

        /// <summary>
        /// Update all attributes to be what is passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Null or updated data</returns>
        public AvatarModel Update(AvatarModel data)
        {
            if (data == null)
            {
                return null;
            }
            var myReturn = avatarList.Find(n => n.Id == data.Id);

            myReturn.Update(data);

            return myReturn;
        }

        /// <summary>
        /// Remove the Data item if it is in the list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for success, else false</returns>
        public bool Delete(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return false;
            }

            var myData = avatarList.Find(n => n.Id == Id);
            var myReturn = avatarList.Remove(myData);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Avatars</returns>
        public List<AvatarModel> Index()
        {
            return avatarList;
        }

        /// <summary>
        /// Reset the Data, and reload it
        /// </summary>
        public void Reset()
        {
            avatarList.Clear();
            Initialize();
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
            Create(new AvatarModel("/Avatar/avatar1.png", "Avatar1", "Avatar1", 1));
            Create(new AvatarModel("/Avatar/avatar2.png", "Avatar2", "Avatar2", 1));
            Create(new AvatarModel("/Avatar/avatar3.png", "Avatar3", "Avatar3", 1));
            Create(new AvatarModel("/Avatar/avatar4.png", "Avatar4", "Avatar4", 1));
            Create(new AvatarModel("/Avatar/avatar5.png", "Avatar5", "Avatar5", 1));
            Create(new AvatarModel("/Avatar/avatar6.png", "Avatar6", "Avatar6", 1));
            Create(new AvatarModel("/Avatar/avatar7.png", "Avatar7", "Avatar7", 1));
            Create(new AvatarModel("/Avatar/avatar8.png", "Avatar8", "Avatar8", 1));
            Create(new AvatarModel("/Avatar/avatar9.png", "Avatar9", "Avatar9", 1));
            Create(new AvatarModel("/Avatar/avatar10.png", "Avatar10", "Avatar10", 1));
            Create(new AvatarModel("/Avatar/defaultavatar1.png", "Default", "Default", 1));
        }
    }
}