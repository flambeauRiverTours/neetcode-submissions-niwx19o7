public class Meal {
    private double cost;
    private bool takeOut;
    private string main;
    private string drink;

    public double getCost() {
        return this.cost;
    }

    public bool getTakeOut() {
        return this.takeOut;
    }

    public string getMain() {
        return this.main;
    }

    public string getDrink() {
        return this.drink;
    }

    public void setCost(double cost) {
        this.cost = cost;
    }

    public void setTakeOut(bool takeOut) {
        this.takeOut = takeOut;
    }

    public void setMain(string main) {
        this.main = main;
    }

    public void setDrink(string drink) {
        this.drink = drink;
    }
}

public class MealBuilder {

    public MealBuilder() {
        mealInstance = new Meal();
    }

    private Meal mealInstance;

    public MealBuilder addCost(double cost) {
        mealInstance.setCost(cost);
        return this;
    }

    public MealBuilder addTakeOut(bool takeOut) {
        mealInstance.setTakeOut(takeOut);
        return this;
    }

    public MealBuilder addMainCourse(string main) {
        mealInstance.setMain(main);
        return this;
    }

    public MealBuilder addDrink(string drink) {
        mealInstance.setDrink(drink);
        return this;
    }

    public Meal build() {
        return mealInstance;
    }
}
