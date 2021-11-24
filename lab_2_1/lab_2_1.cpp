#include "pch.h"

#include <functional>
#include <iomanip>
#include <iostream>
#include <string>

double get_derivative(
	std::function<double(double)> y,
	double x,
	double delta_x
) {
	return (y(x + delta_x) - y(x)) / delta_x;
}

// 1. Дана функция y=f(x) Вычислить с заданной точностью производные y` в точках x=1.2+0.1*k, k=0,..10
std::tuple<double/*y`*/, double/*x*/, size_t> get_derivative_eps(
	std::function<double(double)> y,
	double x,
	double eps
) {
	double delta_x = 0.1;
	
	double dx_i = get_derivative(y, x, delta_x);
	size_t iterations = 1;
	
	while (true)
	{
		delta_x /= 10;
		const double dx_next = get_derivative(y, x, delta_x);
		
		// Если нужная точность достигнута ..
		if (abs(dx_i - dx_next) < eps)
		{
			// .. то производная вычислена
			dx_i = dx_next;
			break;
		}
		dx_i = dx_next;
		++iterations;
	}

	return  std::make_tuple(dx_i, x, iterations);
}

int main()
{
	setlocale(LC_ALL, "ru_RU");

	auto y = [](double x) { return x * x + 4; };
	auto points_gen = [](size_t k) mutable { return 1.2 + 0.1*k; };
	while (true)
	{
		double eps = 0;
		do
		{
			std::cout << "Enter eps: ";
			std::cin.clear();
			fflush(stdin);
			std::cin >> eps;
		} while (eps <= 0);

		std::cout << "y = x^2+4" << std::endl;
		for (size_t i = 0; i <= 10; i++)
		{
			const auto res = get_derivative_eps(y, points_gen(i), eps);
			std::cout << "x = " << std::setw(4) << std::setprecision(10) << std::get<1>(res)
					  << "; y` = " << std::setprecision(10) << std::get<0>(res)
					  << "; iterations = " << std::get<2>(res) << std::endl;
		}
		
		system("pause");
		system("cls");
	}
}