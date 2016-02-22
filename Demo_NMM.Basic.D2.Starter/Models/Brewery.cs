using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_NMM.Basic.Models
{
    public class Brewery
    {
        #region ENUMERABLES



        #endregion


        #region FIELDS

        private int _id;            
        private string _name;
        private string _address;
        private string _city;
        private AppEnum.StateAbrv _state;
        private string _zip;
        private string _phone;         

        #endregion


        #region PROPERTIES
        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public AppEnum.StateAbrv State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion
    }
}