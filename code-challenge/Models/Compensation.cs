namespace challenge.Models
{
    public class Compensation
    {
        private Employee employee;
        private float salary;
        private string effectiveDate;

        public Compensation() { }

        public void setEmployee(Employee employee) { this.employee = employee; }

        public Employee getEmployee() { return this.employee; }

        public void setSalary(float salary)
        {

            this.salary = salary;

        }

        public float getSalary() { 
        
            return salary;

        }

        public void setEffectiveDate(string effectiveDate) { 
            
            this.effectiveDate = effectiveDate; 
        
        }

        public string getEffectiveDate() { 
        
            return effectiveDate;

        }

        public override bool Equals(object o)
        {

            if (this == o) return true;
            if (!(o.GetType() == typeof(Compensation))) return false;

            Compensation other = (Compensation)o;

            return object.Equals(this.employee, other.employee) && salary == other.salary && effectiveDate == other.effectiveDate;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "{" + "employee: " + getEmployee() + ", Salary: " + getSalary() + ", Effective date: " + getEffectiveDate() + "}";
        }

    }
}
