#include "Test.h"
#pragma once

class Offset : public Test {
    private:
        int result;
        string question1;
        string question2;
    public:
        Offset();
        Offset(int result, string question1, string question2, string fio, string date, string subject);

        string getResult();
        string getQ1();
        string getQ2();

        void setResult(int result);
        void setQ1(string q1);
        void setQ2(string q2);

        void Print() override;
        void Input() override;

        void Hello() override;
};
