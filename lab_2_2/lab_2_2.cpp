#include "pch.h"

#include <functional>
#include <iomanip>
#include <iostream>
#include <string>

double integrate(
	double x_0,
	size_t N,
	double h,
	std::function<double(double)> y
) {
	double x = x_0,
		  integral = h * y(x);

	#pragma omp parallel for reduction(+:integral) private(x)
	for (int j = 1; j <= N; ++j)
	{
		x = x_0 + h * j;
		integral += h * y(x);
	}
	return integral;
}

std::tuple<double/*integral*/, size_t/*N*/, size_t> integrate_by_rectangle_method(
	std::pair<double/*a*/, double/*b*/> interval,
	const double eps,
	std::function<double(double)> y
) {
	size_t N = 2;
	double h = (interval.second - interval.first) / N,
		   integral_i = integrate(interval.first, N, h, y);

	size_t iterations = 1;
	while (true)
	{
		if (N == 0)
			throw std::runtime_error(
				"Заданная точность недостижима. Количество итераций: " + std::to_string(iterations)
				+ ", интеграл: " + std::to_string(integral_i)
			);
		N *= 2;
		h /= 2;
		const auto integral_next = integrate(interval.first, N, h, y);

		// Если нужная точность достигнута ..
		if (abs(integral_i - integral_next) < eps)
		{
			// .. то интеграл вычислен
			integral_i = integral_next;
			break;
		}
		integral_i = integral_next;
		++iterations;
	}

	return std::make_tuple(integral_i, N, iterations);
}

int main()
{
	setlocale(LC_ALL, "ru_RU");

	auto y = [](double x) { return x * x; };
	while (true)
	{
		std::pair<double, double> interval;

		std::cout << "Enter interval [a, b]." << std::endl;
		std::cout << "Enter a: ";
		std::cin >> interval.first;
		std::cout << "Enter b: ";
		std::cin >> interval.second;

		double eps = 0;
		do
		{
			std::cout << "Enter eps: ";
			std::cin >> eps;
		} while (eps <= 0);


		std::cout << "y = x^2+4" << std::endl;
		try
		{
			const auto res = integrate_by_rectangle_method(interval, eps, y);
			std::cout << "N = " << std::setw(4) << std::setprecision(10) << std::get<1>(res)
					  << "; integral = " << std::setprecision(10) << std::get<0>(res)
					  << "; iterations = " << std::get<2>(res) << std::endl;
		}
		catch (const std::exception &e)
		{
			std::cerr << e.what() << std::endl;
			system("pause");
			system("cls");
			continue;
		}
		system("pause");
		system("cls");
	}

}