#include "NetworkComponent.h"

NetworkComponent::NetworkComponent()
{
	NetworkComponent(NULL, NULL, 0, 0, 0, 0);
}

NetworkComponent::NetworkComponent(const char* texture, SDL_Renderer* renderer, int x, int y, int w, int h) :GameObject(texture, renderer, x, y, w, h) {}

void NetworkComponent::setMaxConnections(int maxConnections)
{
	this->maxNumberOfConnections = maxConnections;
}

ComponentType NetworkComponent::getType()
{
	return type;
}

void NetworkComponent::checkColision(Vector2D_f pos)
{
	return;
}

void NetworkComponent::Update()
{
	return;
}
