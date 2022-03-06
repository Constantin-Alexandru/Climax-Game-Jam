#pragma once

#include <SDL.h>
#include "Vector2D_f.h"

class GameObject
{
public:
	GameObject();
	GameObject(const char* texture, SDL_Renderer* renderer, int x, int y, int w, int h);
	~GameObject();

	virtual void Update();
	void Render();
	
	Vector2D_f getPosition();

	virtual void checkColision(Vector2D_f pos);

protected:

	Vector2D_f pos;

	SDL_Texture* objTexture = NULL;
	SDL_Rect srcRect, destRect;
	SDL_Renderer* renderer = NULL;
};

