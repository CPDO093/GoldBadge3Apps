using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public class BadgeRepo
    {
        Dictionary<int, List<string>> accessDirectory = new Dictionary<int, List<string>>();


        // method for adding badge
        // adding and removine multipule doors one at a time needed
        public bool AddBadgeAndAddDoors(int badgeNum, List<string> door)
        {
            int startingCount = accessDirectory.Count();
            accessDirectory.Add(badgeNum, door);
            bool wasAdded = (accessDirectory.Count() > startingCount) ? true : false;
            return wasAdded;

        }
        // method to list all badges
        public List<KeyValuePair<int, List<string>>> ListAllBadgesAndAccess()
        {
            return accessDirectory.ToList();

        }

        public List<KeyValuePair<int, List<string>>> GetBadgeById(int badgeNum)
        {
            return accessDirectory.Where(i => i.Key == badgeNum).ToList();

        }

        // method for updateing badge
        public void UpdateBadgeAccess(int badgeNum, string door)
        {
            accessDirectory[badgeNum].Add(door);
        }

        public void RemoveBadgeAcess(int badgeNum, string door)
        {
            accessDirectory[badgeNum].Remove(door);

        }
    }
}
