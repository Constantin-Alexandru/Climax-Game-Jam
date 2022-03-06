#include "Connection.h"

Connection::Connection()
{
	Connection(NULL, NULL, 0, 0, 0, 0);
}

Connection::Connection(const char* texture, SDL_Renderer* renderer, int x, int y, int w, int h) : GameObject(texture, renderer, x, y, w, h) {}

void Connection::setLink1(NetworkComponent end1)
{
	this->end1 = end1;
}

void Connection::setLink2(NetworkComponent end2)
{
	this->end2 = end2;
}

NetworkComponent Connection::getLink1()
{
	return end1;
}

NetworkComponent Connection::getLink2()
{
	return end2;
}

ComponentType Connection::getLink1Type()
{
	return end1.getType();
}

ComponentType Connection::getLink2Type()
{
	return end2.getType();
}

void Connection::Render()
{
	SDL_RenderDrawLine(renderer, (int)end1.getPosition().x, (int)end1.getPosition().y, (int)end2.getPosition().x, (int)end2.getPosition().y);
}

void Connection::Update()
{
	return;
}

void Connection::checkColision(Vector2D_f pos)
{
	return;
}
