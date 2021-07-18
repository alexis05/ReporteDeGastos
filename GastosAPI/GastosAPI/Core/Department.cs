using System;
namespace GastosAPI.Core
{
    public class Department
    {

        private string name;
        private User supervisor;

        internal Department(string name, User supervisor)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("The name of the department is required.");
            if (supervisor == null) throw new Exception("The supervisor is required");

            this.name = name;
            this.supervisor = supervisor;
        }

        internal void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("The name of the department is required.");

            this.name = name;
        }

        internal void ChangeSupervisor(User newSupervisor)
        {
            if (newSupervisor == null) throw new Exception("The new supervisor is required");

            this.supervisor = newSupervisor;
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public User Supervisor
        {
            get
            {
                return this.supervisor;
            }
        }


    }
}
