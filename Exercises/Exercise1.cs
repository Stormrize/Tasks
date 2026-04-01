class Exercise1 
{

	private static String Fitnesstracker(int stepsGoal, int stepsDone)
	{
		if (stepsDone < 0 || stepsGoal < 0) return "Відйемні числа!";
		float percentage = (float)stepsDone / stepsGoal * 100;

		switch (percentage)
		{
			case > 200: return "Ну ти просто машина!";
			case > 100: return "Ціль досягнута! Ви молодець!";
			case > 90: return "Майже дійшли до цілі!";
			case > 70: return "Ще трохи порухайтесь!";
			default: return "Треба більше рухатися!";
		}
	}

	private static float ElectricityToPay(int kWh)
	{
		if (kWh < 0) return 0;
		float result;
		if (kWh > 600)
		{
			result = (kWh - 600) * 1.92f;
			result = 600;
		}
		if (kWh > 100)
		{
			result = (kWh - 100) * 1.68f;
			result = 100;
		}
		result = kWh * 1.44f;
		return result;
	}

	private static float Cashback(int payment, bool card)
	{
		if (payment < 0) return 0;
		float result;
		if (payment > 20000 && card)
		{
			result = payment * 0.1f;
		}
		else if (payment > 10000 && !card)
		{
			result = payment * 0.05f;
		}
		else if (payment > 10000 && card)
		{
			result = payment * 0.08f;
		}
		else
		{
			result = payment * 0.01f;
		}

		return result;
	}
	
	public static void Main()
	{
		Console.WriteLine("Скільки кроків ви хочете пройти сьогодні?");
		int stepsGoal = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Скільлки ви кроків вже пройшли?");
		int stepsDone = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine(Fitnesstracker(stepsGoal, stepsDone));
		Console.WriteLine("Скільки ви спожили електроенргії цього місяця в кіловатах на годину?");
		int kWh =  Convert.ToInt32(Console.ReadLine());
		Console.WriteLine(ElectricityToPay(kWh));
		Console.WriteLine("Скільки вам потрібно оплатити?");
		int payment = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("У вас є карта лояльності? так | ні");
		String answer = Console.ReadLine();
		bool card;
		if (answer.Equals("так")) card = true;
		else card = false;
		Console.WriteLine(Cashback(payment, card));
	}
}