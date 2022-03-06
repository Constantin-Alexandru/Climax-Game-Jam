#include "Vector2D_f.h"

Vector2D_f::Vector2D_f(float x, float y)
{
	this->x = x;
	this->y = y;
}

Vector2D_f& Vector2D_f::Add(const Vector2D_f v)
{
	this->x += v.x;
	this->y += v.y;

	return *this;
}

Vector2D_f& Vector2D_f::Subtract(const Vector2D_f v)
{
	this->x -= v.x;
	this->y -= v.y;

	return *this;
}

Vector2D_f& Vector2D_f::Multiply(const Vector2D_f v)
{
	this->x *= v.x;
	this->y *= v.y;

	return *this;
}

Vector2D_f& Vector2D_f::Divide(const Vector2D_f v)
{
	this->x /= v.x;
	this->y /= v.y;

	return *this;
}

Vector2D_f& operator+(Vector2D_f& v1, const Vector2D_f& v2)
{
	return v1.Add(v2);
}

Vector2D_f& operator-(Vector2D_f& v1, const Vector2D_f& v2)
{
	return v1.Subtract(v2);
}

Vector2D_f& operator*(Vector2D_f& v1, const Vector2D_f& v2)
{
	return v1.Multiply(v2);
}

Vector2D_f& operator/(Vector2D_f& v1, const Vector2D_f& v2)
{
	return v1.Divide(v2);
}


Vector2D_f& Vector2D_f::operator+=(const Vector2D_f& v)
{
	return this->Add(v);
}

Vector2D_f& Vector2D_f::operator-=(const Vector2D_f & v)
{
	return this->Subtract(v);
}

	Vector2D_f& Vector2D_f::operator*=(const Vector2D_f & v)
{
	return this->Multiply(v);
}

Vector2D_f& Vector2D_f::operator/=(const Vector2D_f & v)
{
	return this->Divide(v);
}


std::istream& operator>>(std::istream & in, const Vector2D_f & v)
{
	in >> v.x >> v.y;

	return in;
}

std::ostream& operator<<(std::ostream & out, const Vector2D_f v)
{
	out << "( " << v.x << " , " << v.y << " )";

	return out;
}