#include "pch.h"


#include <algorithm>
#include <functional>
#include <iomanip>
#include <iostream>
#include <iterator>
#include <list>
#include <map>
#include <numeric>
#include <string>
#include <vector>

// Newton's divided difference interpolation formula
double interpolate_via_Newton(double x, std::map<double/*x*/, double/*y*/> const &interpolation_table)
{
	auto i_cur = interpolation_table.begin();
	const auto i_end = interpolation_table.end();
	using iterator_t = decltype(i_cur);
	
	std::function<double(iterator_t, iterator_t)> get_divided_difference;
	get_divided_difference = 
		[x, &interpolation_table, &get_divided_difference]
		(iterator_t front, iterator_t back)
	{
		if(front == back)
			return front->second;

		auto front_next = front; ++front_next;
		auto back_next  = back;	 --back_next;
			
		return (get_divided_difference(front_next, back)
			  - get_divided_difference(front, back_next)
			)
			/ (back->first - front->first);
	};

	double result = 0;
	for(; i_cur != i_end; ++i_cur)
	{
		double formula_member = 1;
		
		auto k_cur = interpolation_table.begin();
		for (; k_cur != i_cur; ++k_cur)
			formula_member *= x - k_cur->first;

		formula_member *= get_divided_difference(interpolation_table.begin(), i_cur);

		result += formula_member;
	}
	return result;
}

int main()
{
	setlocale(LC_ALL, "ru_RU");

	auto y = [](double x) { return sqrt(x); };
	
	std::cout << "y = sqrt(x)" << std::endl << std::endl;
	std::map<double, double> interpolation_table{
		{100, 10},
		{121, 11},
		{144, 12},
		{25, 5},
		{4, 2},
	};
	for (int i = 40; i > 0; i -= 8)
		interpolation_table.emplace(i, y(i));
	
	std::cout << "Interpolation table:" << std::endl;
	for (const auto x_y : interpolation_table)
	{
		std::cout << "x = " << std::setw(6) << x_y.first
			<< "; y = " << x_y.second
			<< "\n";
	}
	std::cout << std::endl;

	auto print_interpolated_f_x = [&interpolation_table, &y](double x)
	{
		const auto interpolated_val = interpolate_via_Newton(x, interpolation_table);
		std::cout << "x = " << std::setw(6) << x
			<< "; y = " << std::setw(6) << std::setprecision(5) << interpolated_val
			<< "; error = " << std::setw(6) << std::setprecision(5) << std::abs(y(x) - interpolated_val)
			<< "\n";
	};

	std::cout << "Interpolation results:" << std::endl;
	for (const auto x_y : interpolation_table)
		print_interpolated_f_x(x_y.first);
	
	std::cout << std::endl;
	print_interpolated_f_x(115);
	print_interpolated_f_x(36);
	print_interpolated_f_x(64);
	std::cout << std::endl;

	system("pause");
	system("cls");
}
