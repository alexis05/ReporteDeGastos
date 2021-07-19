using System;
namespace GastosAPI.Core
{
    public class Department
    {

        private string name;
        private Account supervisor;

        internal Department(string name, Account supervisor)
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

        internal void ChangeSupervisor(Account newSupervisor)
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

        public Account Supervisor
        {
            get
            {
                return this.supervisor;
            }
        }


    }
}
