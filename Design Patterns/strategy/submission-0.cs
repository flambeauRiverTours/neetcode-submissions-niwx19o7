public class Person {
    private string lastName;
    private int age;
    private bool married;

    public Person(string lastName, int age, bool married) {
        this.lastName = lastName;
        this.age = age;
        this.married = married;
    }

    public string getLastName() {
        return lastName;
    }

    public int getAge() {
        return age;
    }

    public bool isMarried() {
        return married;
    }
}

public interface IPersonFilter {
    bool apply(Person person);
}

public class AdultFilter : IPersonFilter {
    // Implement Adult filter
    public AdultFilter(){

    }

    public bool apply(Person person){
        return person.getAge() > 17;
    }
}

public class SeniorFilter : IPersonFilter {
    // Implement Senior filter
    public SeniorFilter(){

    }

    public bool apply(Person person){
        return person.getAge() > 64;
    }
}

public class MarriedFilter : IPersonFilter {
    // Implement Married filter
    public MarriedFilter(){

    }

    public bool apply(Person person){
        return person.isMarried();
    }
}

public class PeopleCounter {
    private IPersonFilter filter;

    public void setFilter(IPersonFilter filter) {
        this.filter = filter;
    }

    public int count(List<Person> people) {
        int count = 0;
        foreach(Person person in people){
            if(filter.apply(person)) {count++;}
        }
        return count;
    }
}
