using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCompanyOutings
{
    public enum EventType { Golf = 1, Bowling, AmusmentPark, Concert = 4 }

    public class CompanyOuting
    {
        // class has the following attributes
        // event type
        public EventType EventType { get; set; }
        // number of people in attendace
        public int PeopleAttending { get; set; }
        // date
        public DateTime Date { get; set; }
        // total cost per person for event
        public double IndivCost { get; set; }
        // total cost of event
        public double EventCost { get; set; }

        public CompanyOuting() { }
        public CompanyOuting(EventType type)
        {
            EventType = type;
        }
        public CompanyOuting(EventType type, int numPeople) : this(type)
        {
            PeopleAttending = numPeople;
        }
        public CompanyOuting(EventType type, int numPeople, DateTime date) : this(type, numPeople)
        {
            Date = date;
        }
        public CompanyOuting(EventType type, int numPeople, DateTime date, double indivCost) : this(type, numPeople, date)
        {
            IndivCost = indivCost;
        }
        public CompanyOuting(EventType type, int numPeople, DateTime date, double indivCost, double totalCost) : this(type, numPeople, date, indivCost)
        {
            EventCost = totalCost;
        }
    }
}
