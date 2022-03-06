#pragma once

#include <iostream>

class Vector2D_i
{
	int x;
	int y;

	Vector2D_i(int x = 0, int y = 0);

	Vector2D_i& Add(const Vector2D_i v);	
	Vector2D_i& Subtract(const Vector2D_i v);
	Vector2D_i& Multiply(const Vector2D_i v);
	Vector2D_i& Divide(const Vector2D_i v);

	friend Vector2D_i& operator+(Vector2D_i& v1, const Vector2D_i& v2);
	friend Vector2D_i& operator-(Vector2D_i& v1, const Vector2D_i& v2);
	friend Vector2D_i& operator*(Vector2D_i& v1, const Vector2D_i& v2);
	friend Vector2D_i& operator/(Vector2D_i& v1, const Vector2D_i& v2);

	Vector2D_i& operator+=(const Vector2D_i& v);
	Vector2D_i& operator-=(const Vector2D_i& v);
	Vector2D_i& operator*=(const Vector2D_i& v);
	Vector2D_i& operator/=(const Vector2D_i& v);

	friend std::istream& operator>>(std::istream& in, const Vector2D_i& v);
	friend std::ostream& operator<<(std::ostream& out, const Vector2D_i v);
};

