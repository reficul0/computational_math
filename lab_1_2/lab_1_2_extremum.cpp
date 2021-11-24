#include "pch.h"


#include <algorithm>
#include <functional>
#include <iostream>
#include <string>

double clamp(double n, double lower, double upper)
{
	return std::max(lower, std::min(n, upper));
}

// Метод сканирования.
// Исходное уравнение: x^2 + 4
// 
std::pair<double, size_t> compute_min_via_scanning_method(
	std::pair<double/*a*/, double/*b*/> interval,
	const double eps,
	std::function<double(double)> f_x,
	std::function<bool(double, double)> comparator
) throw(std::runtime_error)
{
	double step = (interval.second - interval.first) / 2;
	double x_i = interval.first;
	double f_x_i = f_x(x_i);
	size_t iterations = 1;

	while (true)
	{
		auto x_next = x_i + step;
		// Если совершив шаг выходим за границу интервала ..
		if (x_next > interval.second || x_next < interval.first)
		{
			// .. сменим направление движения ..
			step = -step / 2;
			// .. и пойдём в обратную сторону
			x_next = ::clamp(x_i + step, interval.first, interval.second);
		}
		
		const auto f_x_next = f_x(x_next);

		// Если функция начала возрастать ..
		if (comparator(f_x_next, f_x_i))
		{
			// .. и нужная точность достигнута ..
			if (abs(x_i - x_next) <= eps)
			{
				// .. то корень найден
				x_i = x_next;
				break;
			}
			step = -step / 2;
		}
		
		x_i = x_next;
		f_x_i = f_x_next;
		++iterations;

		if (iterations > 10000)
			throw std::runtime_error(
				"Обнаружено зависание, количество итераций: " + std::to_string(iterations)
				+ ", корень: " + std::to_string(x_i)
			);
	}

	return std::make_pair(x_i, iterations);
}

int main()
{
	setlocale(LC_ALL, "ru_RU");
	
	auto f_x = [](double x) { return x * x + 4; };
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
		
		try
		{
			const auto res = compute_min_via_scanning_method(interval, eps, f_x, std::greater<>());
			std::cout << "\nx = " << res.first << "; iterations = " << res.second << "; f(x) = " << f_x(res.first) << std::endl;
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