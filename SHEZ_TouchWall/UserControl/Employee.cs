using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEZ_TouchWall
{
    class Employee 
    {
        public long EmployeeID { get; set; }

        public string LastName { get; set; }
        string _FirstName;
        public string FirstName { get; set; }

        public string Title { get; set; }

        public string TitleOfCourtesy { get; set; }

        public Nullable<System.DateTime> BirthDate { get; set; }

        public Nullable<System.DateTime> HireDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string HomePhone { get; set; }

        public string Extension { get; set; }

        public string Photo { get; set; }

        public string Notes { get; set; }

        public Nullable<long> ReportsTo { get; set; }

        public string Email { get; set; }

        public string GroupName { get; set; }

        public string PageHeader { get; set; }
        public string PageContent { get; set; }

        string _FullName = null;
        public string FullName
        {
            get
            {
                if (_FullName == null)
                    _FullName = String.Format("{0} {1}", FirstName, LastName);
                return _FullName;
            }
        }
    }
}
