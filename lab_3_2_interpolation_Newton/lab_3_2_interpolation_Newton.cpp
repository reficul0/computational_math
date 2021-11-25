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

	std::function<double(std::list<decltype(i_cur)>)> get_divided_difference;
	get_divided_difference = 
		[x, &interpolation_table, &get_divided_difference]
		(std::list<decltype(i_cur)> divided_difference_args)
	{
		if(divided_difference_args.size() == 1)
			return divided_difference_args.front()->second;

		auto args_wo_first = divided_difference_args;
		args_wo_first.pop_front();

		auto args_wo_last = divided_difference_args;
		args_wo_last.pop_back();

		return (get_divided_difference(args_wo_first) - get_divided_difference(args_wo_last))
			/ (divided_difference_args.back()->first - divided_difference_args.front()->first);
	};

	double result = 0;
	for(; i_cur != i_end; ++i_cur)
	{
		double formula_member = 1;
		std::list<decltype(i_cur)> divided_difference_args;
		
		auto k_cur = interpolation_table.begin();
		for (; k_cur != i_cur; ++k_cur)
		{
			divided_difference_args.push_back(k_cur);
			formula_member *= x - k_cur->first;
		}
		divided_difference_args.push_back(i_cur);

		if(divided_difference_args.empty() == false)
			formula_member *= get_divided_difference(divided_difference_args);

		result += formula_member;
	}
	return result;
}

int main()
{
	setlocale(LC_ALL, "ru_RU");

	auto y = [](double x) { return sqrt(x); };
	
	std::cout << "y = sqrt(x)" << std::endl;
	std::map<double, double> interpolation_table{
		{100, 10},
		{121, 11},
		{144, 12},
		{25, 5},
		{4, 2},
	};
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
		const auto interpolation_val = interpolate_via_Newton(x, interpolation_table);
		std::cout << "x = " << std::setw(6) << x
			<< "; y = " << std::setw(6) << std::setprecision(5) << interpolation_val
			<< "; error = " << std::setw(6) << std::setprecision(5) << std::abs(y(x) - interpolation_val)
			<< "\n";
	};

	std::cout << "Interpolation results:" << std::endl;
	for (const auto x_y : interpolation_table)
		print_interpolated_f_x(x_y.first);
	print_interpolated_f_x(115);
	print_interpolated_f_x(36);
	print_interpolated_f_x(64);
	std::cout << std::endl;

	system("pause");
	system("cls");
}
