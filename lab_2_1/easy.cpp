#include "pch.h"

#include <functional>
#include <iomanip>
#include <iostream>
#include <string>

double y(double x)
{
	return x * x + 4;
}

double get_derivative(
	double x,
	double delta_x
) {
	return (y(x + delta_x) - y(x)) / delta_x;
}

struct DerativeResult
{
	double dy;
	double x;
	size_t iterations;
};

// 1. Дана функция y=f(x) Вычислить с заданной точностью производные y` в точках x=1.2+0.1*k, k=0,..10
DerativeResult get_derivative_eps(
	double x,
	double eps
) {
	double delta_x = 0.1;

	double dx_i = get_derivative(x, delta_x);
	size_t iterations = 1;

	while (true)
	{
		delta_x /= 10;
		const double dx_next = get_derivative(x, delta_x);

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

	return DerativeResult{ dx_i, x, iterations };
}

int fake_main()
{
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
			const auto res = get_derivative_eps(1.2 + 0.1*i, eps);
			std::cout << "x = " << std::setw(4) << std::setprecision(10) << res.x
				<< "; y` = " << std::setprecision(10) << res.dy
				<< "; iterations = " << res.iterations << std::endl;
		}

		system("pause");
		system("cls");
	}
}