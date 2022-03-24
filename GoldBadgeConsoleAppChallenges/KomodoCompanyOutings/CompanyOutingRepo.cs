using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCompanyOutings
{
    public class CompanyOutingRepo
    {
        List<CompanyOuting> _outings = new List<CompanyOuting>();
        //Create
        // method for adding an outing event
        public bool AddNewCompOuting(CompanyOuting outing)
        {
            int startingCount = _outings.Count();
            _outings.Add(outing);
            bool wasAdded = (_outings.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        // method for list of all outings
        public List<CompanyOuting> GetAllOutings()
        {
            return _outings;
        }
        // method for listing combined cost of all outings
        public double GetTotalCombinedCost()
        {
            double totalCost = 0;
            foreach (var outing in _outings)
            {
                totalCost += outing.EventCost;

            }
            return totalCost;
        }

        // method for listing combind cost by type (list)

        public double GetOutingCostByType(EventType eventType)
        {
            double totalCost = 0;
            foreach (var outing in _outings)
            {
                if (eventType == outing.EventType)
                {
                    totalCost += outing.EventCost;

                }
            }
            return totalCost;

        }

        //Update
        // method for updating outing event
        public bool UpdateExistingOuting(DateTime date)
        {
            CompanyOuting newinfo = new CompanyOuting();

            foreach (var outing in _outings)
            {
                if (date == outing.Date)
                {
                    newinfo.EventType = outing.EventType;
                    newinfo.PeopleAttending = outing.PeopleAttending;
                    newinfo.Date = outing.Date;
                    newinfo.IndivCost = outing.IndivCost;
                    newinfo.EventCost = outing.EventCost;
                }
            }
            return true;
        }
    }
}
