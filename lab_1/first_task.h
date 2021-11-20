#pragma once

namespace first_task
{
	// ����� ��������.
	// �������� ���������: 4x + e^x = 0
	// ��������: [a;b] = [-1; 1]
	// 
	// �������� � ���� x=g(x):
	// x = -(e^x)/4 = g(x)
	// ��������� x0:
	// x0 = -(e^0)/4 = -1/4
	// ������ ��������:
	// x1 = -(e^(-1/4))/4 = -0.19470019576


	/**
	 * \brief ����� ������ ��������� 4x + e^x = 0
	 * \param interval [a;b], ��� a-first, b-second
	 * \param eps ��������
	 * \param g_x �������, ������� ������� �������� ������� x=g(x)
	 * \return ����, ��� ������-first, ���������� ��������-second
	 */
	std::pair<double, size_t> compute_via_iteration_method(
		std::pair<double/*a*/, double/*b*/> interval,
		const double eps,
		std::function<double(double)> g_x
	) throw(std::runtime_error)
	{
		double x0 = (interval.first + interval.second) / 2;
		double x_i = x0;
		size_t iterations = 1;

		while (true)
		{
			const auto x_next = g_x(x_i);

			if (x_next > interval.second)
				throw std::runtime_error(
					"������� ������ �� ����������� ���������: [" + std::to_string(interval.first)
					+ "; " + std::to_string(interval.second) + "]"
				);

			// ���� ������ �������� ���������� ..
			if (abs(x_next - x_i) <= eps)
			{
				// .. �� ������ ������
				x_i = x_next;
				break;
			}
			x_i = x_next;
			++iterations;

			if (iterations > 10000)
				throw std::runtime_error(
					"���������� ���������, ������� ������� ���������� ��������: " + std::to_string(iterations)
					+ ", ������: " + std::to_string(x_i)
				);
		}

		return std::make_pair(x_i, iterations);
	}

	/**
	 * \brief ��������� ������� ����������
	 * \param interval interval [a;b], ��� a-first, b-second
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
				throw std::runtime_error("g`(x) �� ������������� ������� ���������� � �����: " + std::to_string(x));
		};

		check(interval.first);
		check(interval.second);
	}

	void show()
	{

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
				// � ����� ������ g`(x)==g(x)
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
}