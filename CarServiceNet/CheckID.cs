using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceNet
{
    public static class CheckID
    {
        public static String getNewUserID() 
        {
            int maxID = 0;
            List<users> users = CarServiceDBEntities1.getContext().users.ToList();

            maxID = Convert.ToInt32(users[0].userID);
            foreach (users user in users)
            {
                if (Convert.ToInt32(user.userID) > maxID)
                {
                    maxID = Convert.ToInt32(user.userID);
                }
            }

            maxID++;
            return maxID.ToString();
        }

        public static String getNewRequestID()
        {
            int maxID = 0;
            List<requests> requests = CarServiceDBEntities1.getContext().requests.ToList();

            maxID = Convert.ToInt32(requests[0].requestID);
            foreach (requests request in requests)
            {
                if (Convert.ToInt32(request.requestID) > maxID)
                {
                    maxID = Convert.ToInt32(request.requestID);
                }
            }

            maxID++;
            return maxID.ToString();
        }

        public static int getNewMessageID()
        {
            int maxID = 0;

            List<changeStatusMessages> messages = CarServiceDBEntities1.getContext().changeStatusMessages.ToList();

            if (messages.Count > 0)
            {
                maxID = messages[0].id;
            }

            foreach (changeStatusMessages message in messages)
            {
                if (message.id > maxID)
                {
                    maxID = message.id;
                }
            }

            maxID++;
            return maxID;
        }
    }
}
