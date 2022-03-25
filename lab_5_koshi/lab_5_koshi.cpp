#include <functional>
#include <math.h> 
#include <iostream>
#include <map>
#include <iomanip>
#include <stdlib.h>
#include <vector>

void metodRK(
    double x,
    double xLast,
    double y,
    double z,
    double step,
    std::function<double(double, double, double)> f,
    std::function<double(double, double, double)> g,
    std::vector<std::tuple<double, double, double>>& x_y_zContainer)
{
    // h = (xLast - x) / n
    int n = static_cast<int>((xLast - x) / step);

    x_y_zContainer.emplace_back(x, y, z);
    for (int i = 0; i < n; i++)
    {
        double k1 = step * f(x, y, z);
        double l1 = step * g(x, y, z);

        double k2 = step * f(x + step / 2.0, y + k1 / 2.0, z + l1 / 2.0);
        double l2 = step * g(x + step / 2.0, y + k1 / 2.0, z + l1 / 2.0);

        double k3 = step * f(x + step / 2.0, y + k2 / 2.0, z + l2 / 2.0);
        double l3 = step * g(x + step / 2.0, y + k2 / 2.0, z + l2 / 2.0);

        double k4 = step * f(x + step, y + k3, z + l3);
        double l4 = step * g(x + step, y + k3, z + l3);

        y += (k1 + 2 * k2 + 2 * k3 + k4) / 6.0;
        z += (l1 + 2 * l2 + 2 * l3 + l4) / 6.0;

        x += step;
        x_y_zContainer.emplace_back(x, y, z);
    }
}

int main()
{
    auto f = [](double x, double y, double z)
    {
        return (z-y)*x;
    };
	auto g = [](double x, double y, double z)
    {
        return (z + y) * x;
    };

    double step = .1;

    std::cout << "Enter step: ";
    std::cin >> step;
    double xFirst = .0;
    double xLast = 1.;
    double zFirst = 1.;
    double yFirst = .0;
    
    std::vector<std::tuple<double, double, double>> x_y_zContainer;
    metodRK(xFirst, xLast, yFirst, zFirst, step, f, g, x_y_zContainer);
    
    std::cout << "{\n\ty' = (z-y)*x\n\tz' = (z+y)*x\n}"
				<< "\n\for x from " << xFirst << " to " << xLast
				<< " y(0) = " << yFirst
				<< " z(0) = " << zFirst << std::endl;

    std::cout << "\nSolution:" << std::setprecision(5);
    std::cout << std::endl
        << std::setw(8) << std::left << "x"
        << std::setw(8) << std::left << " y"
        << std::setw(8) << std::left << "  z" << std::endl;
    for (auto const& x_y_z : x_y_zContainer)
    {
        double x, y, z;
        std::tie(x, y, z) = x_y_z;
        std::cout << std::endl
    		<< std::setw(8) << std::left << x << " "
    		<< std::setw(8) << std::left << y << " "
            << std::setw(8) << std::left << z << std::endl;
    }

    std::cout << "========================================================================" << std::endl;

    return 0;
}