#include "Vector2D_i.h"

Vector2D_i::Vector2D_i(int x, int y)
{
	this->x = x;
	this->y = y;
}

Vector2D_i& Vector2D_i::Add(const Vector2D_i v)
{
	this->x += v.x;
	this->y += v.y;

	return *this;
}

Vector2D_i& Vector2D_i::Subtract(const Vector2D_i v)
{
	this->x -= v.x;
	this->y -= v.y;

	return *this;
}

Vector2D_i& Vector2D_i::Multiply(const Vector2D_i v)
{
	this->x *= v.x;
	this->y *= v.y;

	return *this;
}

Vector2D_i& Vector2D_i::Divide(const Vector2D_i v)
{
	this->x /= v.x;
	this->y /= v.y;

	return *this;
}

Vector2D_i& operator+(Vector2D_i& v1, const Vector2D_i& v2)
{
	return v1.Add(v2);
}

Vector2D_i& operator-(Vector2D_i& v1, const Vector2D_i& v2)
{
	return v1.Subtract(v2);
}

Vector2D_i& operator*(Vector2D_i& v1, const Vector2D_i& v2)
{
	return v1.Multiply(v2);
}

Vector2D_i& operator/(Vector2D_i& v1, const Vector2D_i& v2)
{
	return v1.Divide(v2);
}


Vector2D_i& Vector2D_i::operator+=(const Vector2D_i& v)
{
	return this->Add(v);
}

Vector2D_i& Vector2D_i::operator-=(const Vector2D_i& v)
{
	return this->Subtract(v);
}

Vector2D_i& Vector2D_i::operator*=(const Vector2D_i& v)
{
	return this->Multiply(v);
}

Vector2D_i& Vector2D_i::operator/=(const Vector2D_i& v)
{
	return this->Divide(v);
}


std::istream& operator>>(std::istream& in, const Vector2D_i& v)
{
	in >> v.x >> v.y;

	return in;
}

std::ostream& operator<<(std::ostream& out, const Vector2D_i v)
{
	out << "( " << v.x << " , " << v.y << " )";

	return out;
}