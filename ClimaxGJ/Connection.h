#pragma once

//#include "GameObject.h"

#include "NetworkComponent.h"

class Connection: GameObject
{
public:
	Connection();
	Connection(const char* texture, SDL_Renderer* renderer, int x, int y, int w, int h);

	void setLink1(NetworkComponent end1);
	void setLink2(NetworkComponent end2);

	NetworkComponent getLink1();
	NetworkComponent getLink2();

	ComponentType getLink1Type();
	ComponentType getLink2Type();

	void Render();


	virtual void Update() override;
	virtual void checkColision(Vector2D_f pos) override;
private:
	NetworkComponent end1;
	NetworkComponent end2;
};

