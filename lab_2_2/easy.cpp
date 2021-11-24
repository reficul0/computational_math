#include "pch.h"

#include <functional>
#include <iomanip>
#include <iostream>
#include <string>

double y(double x)
{
	return x * x + 4;
}

struct IntegrationResult
{
	double integral;
	size_t N;
	size_t iterations;
};

double integrate_by_left_rectangles_method(
	double x_0,
	size_t N,
	double h
) {
	double x = x_0,
		   integral = h * y(x);

	for (int j = 1; j <= N; ++j)
	{
		x += h;
		integral += h * y(x);
	}
	return integral;
}

IntegrationResult integrate_by_left_rectangles_method_eps(
	double a,
    double b,
	const double eps
) {
	size_t N = 2;
	double h = (b - a) / N,
		   integral_i = integrate_by_left_rectangles_method(a, N, h);

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
		const auto integral_next = integrate_by_left_rectangles_method(a, N, h);

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

	return IntegrationResult{ integral_i, N, iterations };
}

int fake_main()
{
	setlocale(LC_ALL, "ru_RU");

	auto y = [](double x) { return x * x + 4; };
	while (true)
	{
		double a = 0,
			   b = 0;

		std::cout << "Enter interval [a, b]." << std::endl;
		std::cout << "Enter a: ";
		std::cin >> a;
		std::cout << "Enter b: ";
		std::cin >> b;

		double eps = 0;
		do
		{
			std::cout << "Enter eps: ";
			std::cin >> eps;
		} while (eps <= 0);


		std::cout << "y = x^2+4" << std::endl;
		try
		{
			const auto res = integrate_by_left_rectangles_method_eps(a, b, eps);
			std::cout << "N = " << std::setw(4) << std::setprecision(10) << res.N
				<< "; integral = " << std::setprecision(10) << res.integral
				<< "; iterations = " << res.iterations << std::endl;
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