﻿using System;
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
           
            Create(new AvatarModel("defaultFAvatar.png", "fDefault", "fDefault", 1));
            Create(new AvatarModel("defaultMAvatar.png", "mDefault", "mDefault", 1));
            Create(new AvatarModel("djhAvatar.png", "fartard", "fartard", 1));
            Create(new AvatarModel("dMNAvatar.png", "royal", "royal", 1));
            Create(new AvatarModel("dMN1Avatar.png", "losangeles", "losangels", 1));
            Create(new AvatarModel("dnnAvatar.png", "I tried", "I tried", 1));
            Create(new AvatarModel("dwaAvatar.png", "xoxo", "xoxo", 1));
           
        }
    }
}