using ISP_LAB_1_Lavriv_Ivan.Lab1;

namespace ISP_LAB_1_Lavriv_Ivan;

public partial class Lab1Page : ContentPage
{
    private Calculator calculator;
	public Lab1Page()
    {
        InitializeComponent();
        calculator = new Calculator();  
    }
    private void OnNumberClicked(object sender, EventArgs e)
	{
        Button button = (Button)sender;
        string number = button.Text;
        CalculationEntry.Text += number;
    }
    private void OnOperatorClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string operation = button.Text;
        CalculationEntry.Text += operation;
    }
    private void OnClearClicked(object sender, EventArgs e)
    {
        CalculationEntry.Text = string.Empty;
    }
    private void OnEqualClicked(object sender, EventArgs e)
    {
        string expression = CalculationEntry.Text;

        try
        {
           
            double result = Evaluate(expression);

            
            CalculationEntry.Text = result.ToString();
        }
        catch (Exception ex)
        {
            
            CalculationEntry.Text = "Error: " + ex.Message;
        }
    }
    private double Evaluate(string expression)
    {
        
        string[] elements = expression.Split(new char[] { '+', '-', '*', '/', '%' });

        if (elements.Length == 1)
        {
        
            double num1;
            if (expression.StartsWith("√"))
            {
                num1 = Convert.ToDouble(expression.Substring(1));
                return calculator.Sqrt(num1);
            }
            else if(expression.StartsWith("0"))
            {
                throw new ArgumentException("");
            }

            else
            {
                num1 = Convert.ToDouble(elements[0]);
                return num1;
            }
        }
        else if (elements.Length == 2)
        {
            
            double num1 = Convert.ToDouble(elements[0]);
            double num2 = Convert.ToDouble(elements[1]);

           
            string op = expression.Replace(elements[0], "").Replace(elements[1], "");

            
            switch (op)
            {
                case "+":
                    return calculator.Add(num1, num2);
                case "-":
                    return calculator.Subtract(num1, num2);
                case "*":
                    return calculator.Multiply(num1, num2);
                case "/":
                    return calculator.Divide(num1, num2);
                case "%":
                    return calculator.Modulo(num1, num2);
                default:
                    throw new ArgumentException("Error");
            }
        }
        else
        {
            throw new ArgumentException("Error");
        }
    }

    private void OnModClicked(object sender, EventArgs e)
    {
        CalculationEntry.Text += "%";
    }
    private void OnSqrtClicked(object sender, EventArgs e)
    {
        CalculationEntry.Text += "√";
    }
    private void OnDelClicked(object sender, EventArgs e)
    {
       
        if (!string.IsNullOrEmpty(CalculationEntry.Text))
        {
            CalculationEntry.Text = CalculationEntry.Text.Substring(0, CalculationEntry.Text.Length - 1);
        }
    }
}
