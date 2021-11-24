#include "pch.h"

#include <functional>
#include <iomanip>
#include <iostream>
#include <iterator>
#include <map>
#include <numeric>
#include <string>
#include <unordered_map>
#include <vector>

std::function<double(double)> to_Lagrange_polynomial(std::map<double, double> const &interpolation_table)
{
	auto k_cur = interpolation_table.begin();
	const auto k_end = interpolation_table.end();

	std::vector<std::function<double(double)>> k_polynomial_members;
	for(; k_cur != k_end; ++k_cur)
	{
		auto j_cur = interpolation_table.begin();
		const auto j_end = interpolation_table.end();

		// знаменатель можно представить числом
		double j_denominator = 1;
		// числитель придётся представлять в виде функций от x
		std::vector<std::function<double(double)>> j_numerator_multipliers;
		j_numerator_multipliers.reserve(interpolation_table.size() - 1);
		
		for(; j_cur != j_end; ++j_cur)
		{
			if(j_cur == k_cur)
				continue;
			j_denominator *= (k_cur->first - j_cur->first);

			j_numerator_multipliers.emplace_back([x_j = j_cur->first](double x){ return x - x_j; });
		}
		// Обёртка для множетелей числителя, которая позволяет удобно с ними работать,
		// она перемножает все множетели и возвращает результат, зависящий от x.
		auto j_numerator = [multipliers = std::move(j_numerator_multipliers)](double x)
		{
			return std::accumulate(
				multipliers.begin(), 
				multipliers.end(), 
				double{1},
				[x](double res, std::function<double(double)> const &multiplier)
				{
					return res * multiplier(x);
				}
			);
		};

		// Член полинома готов
		k_polynomial_members.emplace_back(
			[y_k = k_cur->second, j_denominator, j_numerator = std::move(j_numerator)](double x)
			{
				return y_k * j_numerator(x) / j_denominator;
			}
		);
	}

	// Обёртка для членов полинома Лагранжа, которая позволяет удобно с ними работать,
	// она суммирует все множетели и возвращает результат, зависящий от x.
	return [k_polynomial_members = std::move(k_polynomial_members)](double x)
	{
		return std::accumulate(
			k_polynomial_members.begin(),
			k_polynomial_members.end(),
			double{0},
			[x](double res, std::function<double(double)> const &polynomial_member)
			{
				return res + polynomial_member(x);
			}
		);
	};
}

int main()
{
	setlocale(LC_ALL, "ru_RU");

	while (true)
	{
		/*std::pair<double, double> interval;

		std::cout << "Enter interval [a, b]." << std::endl;
		std::cout << "Enter a: ";
		std::cin >> interval.first;
		std::cout << "Enter b: ";
		std::cin >> interval.second;*/

		std::cout << "y = sqrt(x)" << std::endl;
		std::map<double, double> interpolation_table {
			{100, 10},
			{121, 11},
			{144, 12},
			{25, 5},
			{2, 4},
		};
		std::cout << "Interpolation table:" << std::endl;
		for (const auto y_by_x : interpolation_table)
		{
			std::cout << "x = " << y_by_x.first
				<< "; y = " << y_by_x.second
				<< "\n";
		}
		std::cout << std::endl;

		auto Lagrange_polynomial = to_Lagrange_polynomial(interpolation_table);

		auto print_f_x = [&Lagrange_polynomial](double x)
		{
			std::cout << "x = " << x
				<< "; y = " << Lagrange_polynomial(x)
				<< "\n";
		};

		for (const auto y_by_x : interpolation_table)
			print_f_x(y_by_x.first);
		print_f_x(115);
		print_f_x(36);
		std::cout << std::endl;
		
		system("pause");
		system("cls");
	}

}
