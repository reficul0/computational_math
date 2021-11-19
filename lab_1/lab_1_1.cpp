#include "pch.h"

// Метод итераций.
// Исходное уравнение: 4x + e^x = 0
// Интервал: [a;b] = [-1; 1]
// 
// Приводим к виду x=g(x):
// x = -(e^x)/4 = g(x)
// Вычисляем x0:
// x0 = -(e^0)/4 = -1/4
// Первая итерация:
// x1 = -(e^(-1/4))/4 = -0.19470019576


/**
 * \brief найти корень выражения 4x + e^x = 0
 * \param interval [a;b], где a-first, b-second
 * \param eps точность
 * \param g_x функция, которой сведена исходная формула x=g(x)
 * \return пара, где корень-first, количество итераций-second
 */
std::pair<double, size_t> compute_via_iteration_method(
	std::pair<double/*a*/, double/*b*/> interval,
	const double eps,
	std::function<double(double)> g_x
) throw(std::runtime_error)
{
	double x_i = (interval.first + interval.second) / 2;
	size_t iterations = 1;

	while (true)
	{
		const auto x_next = g_x(x_i);

		if (x_next > interval.second)
			throw std::runtime_error(
				"Искомый корень не принадлежит интервалу: [" + std::to_string(interval.first) 
				+ "; " + std::to_string(interval.second) + "]"
			);
		
		// Если нужная точность достигнута ..
		if (abs(x_next - x_i) <= eps)
		{
			// .. то корень найден
			x_i = x_next;
			break;
		}
		x_i = x_next;
		++iterations;

		if (iterations > 10000)
			throw std::runtime_error(
				"Обнаружено зависание, слишком большое количество итераций: " + std::to_string(iterations)
				+ ", корень: " + std::to_string(x_i)
			);
	}

	return std::make_pair(x_i, iterations);
}

/**
 * \brief Проверить условие сходимости
 * \param interval interval [a;b], где a-first, b-second
 * \param derivative_g_x
 */
void check_convergence_condition(
	std::pair<double/*a*/, double/*b*/> interval,
	std::function<double(double)> derivative_g_x
) throw(std::runtime_error)
{
	auto check = [&derivative_g_x](double x)
	{
		if (abs(derivative_g_x(x)) > 1)
			throw std::runtime_error("g`(x) не удовлетворяет условию сходимости в точке: " + std::to_string(x));
	};

	check(interval.first);
	check(interval.second);
}

int main()
{
	setlocale(LC_ALL, "ru_RU");
	
	auto g_x = [](double x) { return -exp(x) / 4; };
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
			// в нашем случае g`(x)==g(x)
			check_convergence_condition(interval, g_x);

			const auto res = compute_via_iteration_method(interval, eps, g_x);
			std::cout << "\nx = " << res.first << "; iterations = " << res.second << std::endl;
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