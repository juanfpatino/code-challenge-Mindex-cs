namespace challenge.Models
{
    public class ReportingStructure
    {

        private Employee employee;
        private int numberOfReports;

        public ReportingStructure(Employee employee, int numberOfReports) { 
        
            this.employee = employee;  
            this.numberOfReports = numberOfReports;

        }

        public void setEmployee(Employee employee)
        {

            this.employee = employee;

        }

        public Employee getEmployee() { 
        
            return employee;

        }

        public void setNumberOfReports(int numberOfReports) { 
        
               this.numberOfReports=numberOfReports;

        }

        public int getNumberOfReports() {

            return numberOfReports;

        }

        public override bool Equals(object o) { 
        
            if(this == o) return true;
            if(!(o.GetType() == typeof(ReportingStructure))) return false; 

            ReportingStructure other = (ReportingStructure)o;

            return object.Equals(this.employee, other.employee) && numberOfReports == other.numberOfReports;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "{" + "employee: " + getEmployee() + ", numberOfReports: " + getNumberOfReports();
        }

    }
}
