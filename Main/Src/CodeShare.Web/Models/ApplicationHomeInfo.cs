using System.Collections.Generic;

namespace CodeShare.Web.Models
{
    public class ApplicationHomeInfo
    {
        public ApplicationHomeInfo()
        {
            NewProjectInfoList = new List<NewProjectInfo>();
        }

        public List<NewProjectInfo> NewProjectInfoList
        {
            get;
            set;
        }
    }
}