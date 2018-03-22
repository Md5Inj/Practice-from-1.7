#include <iostream>
#include "Exam.h"
#include "Offset.h"


using namespace std;

int main()
{
    Offset e;
    e.Input();
    e.Print();

    e.Hello();

    system("read _");
    return 0;
}