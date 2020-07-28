using System;
using System.Collections.Generic;
using System.Text;

namespace Team17OOPTeamProject.Models.Abstract
{
    public class Abstract
    {
        //Fields
        protected string title;
        protected string description;
        //TODO STATUS
        //TODO ASSIGNEE
        protected List<string> comments;
        protected List<string> history;


        //Constructor
        public Abstract(string title, string description /*TODO STATUS*/ /* Assignee */)
        {

        }

        //Properties
        protected string Title
        {
            get => this.title;
            set
            {
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentException("Title should be between 10 and 50 symbols!");
                }
                this.title = value;
            }
        }
        protected string Description
        {
            get => this.description;
            set
            {
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentException("Description should be between 10 and 500 symbols!");
                }
                this.description = value;
            }
        }
        protected List<string> Comments { get => comments; set => comments = value; }
        protected List<string> History { get => history; set => history = value; }

        //Methods 

        // PRINT???
    }
}
