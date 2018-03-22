#include <string>

using namespace std;

#pragma once

class Test {
    private:
        string fio;
        string date;
        string subject;
    public:
        Test();
        Test(string fio, string date, string subject);

        string getFIO();
        string getDate();
        string getSubject();

        void setFIO(string fio);
        void setDate(string date);
        void setSubject(string subject);

        virtual void Print();
        virtual void Input();

        virtual void Hello() = 0;
};