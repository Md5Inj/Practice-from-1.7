#include "Test.h"
#pragma once

class Exam : public Test {
    private:
        int ticketID;
        int rating;
        int type;
    public:
        Exam();
        Exam(int ticketID, int rating, int type, string fio, string date, string subject);

        int getTicketID();
        int getRating();
        string getType();

        void setTicketID(int ID);
        void setRating(int rating);
        void setType(int type);

        void Print() override;
        void Input() override;

        void Hello() override;
};