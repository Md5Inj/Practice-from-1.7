all: hello

hello: main.o Stack.o
	g++ main.o Stack.o -o hello

main.o: main.cpp
	g++ -c main.cpp

Stack.o: Stack.cpp
	g++ -c Stack.cpp

clean:
	rm -rf *.o hello
