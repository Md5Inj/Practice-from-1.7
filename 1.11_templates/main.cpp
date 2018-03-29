#include "Stack.h"
#include <cstring>

using namespace std;

int main()
{
	char input[6];
	double val = 0, whole = 0;
	Stack<double> positive;
	Stack<double> negative;

	while (true)
	{
		cout << "Input the number: "; cin >> input;
		if (strcmp(input, "stop") == 0)
			break;

		val = atoi(input);
		whole = atoi(strchr(input, '.')+1);
		whole *= 0.1;
		if (val > 0)
			val += whole;
		else
			val -= whole;
		
		if (val > 0)
			positive << val;
		else
			negative << val;
	}

	positive >> 11.3;

	positive.Print();
	
	cout << "Newed stack: " << endl;
	Stack<double> newStack;
	newStack = positive;
	newStack.Print();

	Stack<double> st(10);
	st.Print();

	system("pause");
    return 0;
}

