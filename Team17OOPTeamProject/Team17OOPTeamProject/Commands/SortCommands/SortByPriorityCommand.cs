//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using T17.Models.Commands.Abstracts;
//using Team17OOPTeamProject.Models.Contracts;
//using Team17OOPTeamProject.Models.Enums;

//namespace WIM.T17.Commands.SortCommands
//{
//    public class SortByPriorityCommand : Command
//    {
//        public SortByPriorityCommand(IList<string> commandParameters)
//         : base(commandParameters)
//        {
//        }

//        public override string Execute()
//        {
//            List<Priority> prioritySort = new List<Priority>();
           

      
            
//            bool isBugPriority = Enum.TryParse<Priority>(CommandParameters[0], true, out Priority bugPriority);
//            bool isStoryPriority = Enum.TryParse<Priority>(CommandParameters[1], true, out Priority storyPriority);

//            var bPriority = this.Database.Bugs.Select(x => x.Priority > bugPriority - 1).ToList();
//            var sPriority = this.Database.Stories.Select(x => x.Priority > storyPriority - 1).ToList();

//            var sb = new StringBuilder();
//            sb.AppendLine("***SORT BY PRIORITY***");
//            if (bPriority.Count > 0)
//            {
//                foreach (var item in bPriority.)
//                {
//                    sb.AppendLine(item.);
//                }
//            }
//            return sb.ToString();
//        }
//    }
//}
