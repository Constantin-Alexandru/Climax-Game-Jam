#pragma once
#include "GameObject.h"

#include <map>
#include <vector>


enum ComponentType {
	user,
	hub,
	server,
	proxy
};

//std::map<ComponentType, char*> componentSprites;

class NetworkComponent: public GameObject
{
public:
	NetworkComponent();
	NetworkComponent(const char* texture, SDL_Renderer* renderer, int x, int y, int w, int h);


	virtual void Update() override;
	virtual void checkColision(Vector2D_f pos) override;

	void setMaxConnections(int maxConnections);

	ComponentType getType();

private:

	int numberOfConnections;
	int maxNumberOfConnections;

	std::vector<ComponentType> allowedConnections;

	ComponentType type;
};

