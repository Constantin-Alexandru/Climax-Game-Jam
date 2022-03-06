#pragma once

#include <iostream>

class Vector2D_f
{
public:
	float x;
	float y;

	Vector2D_f(float x = 0.0f, float y = 0.0f);

	Vector2D_f& Add(const Vector2D_f v);
	Vector2D_f& Subtract(const Vector2D_f v);
	Vector2D_f& Multiply(const Vector2D_f v);
	Vector2D_f& Divide(const Vector2D_f v);

	friend Vector2D_f& operator+(Vector2D_f& v1, const Vector2D_f& v2);
	friend Vector2D_f& operator-(Vector2D_f& v1, const Vector2D_f& v2);
	friend Vector2D_f& operator*(Vector2D_f& v1, const Vector2D_f& v2);
	friend Vector2D_f& operator/(Vector2D_f& v1, const Vector2D_f& v2);

	Vector2D_f& operator+=(const Vector2D_f& v);
	Vector2D_f& operator-=(const Vector2D_f& v);
	Vector2D_f& operator*=(const Vector2D_f& v);
	Vector2D_f& operator/=(const Vector2D_f& v);
};

