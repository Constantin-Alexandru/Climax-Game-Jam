#include "GameObject.h"

#include "TextureManager.h"

GameObject::GameObject()
{
	GameObject(NULL, NULL, 0, 0, 0, 0);
}

GameObject::GameObject(const char* texture, SDL_Renderer* renderer, int x, int y, int w, int h)
{
	this->renderer = renderer;

	this->objTexture = TextureManager::LoadTexture(texture, renderer);

	pos.x = x;
	pos.y = y;

	destRect.w = w;
	destRect.h = h;

	Engine::gameObjects.push_back(this);

}

GameObject::~GameObject()
{
	return;
}

void GameObject::Update()
{
	return;
}

void GameObject::Render()
{
	if(objTexture != NULL && objTexture != NULL)
		SDL_RenderCopy(renderer, objTexture, &srcRect, &destRect);
}

Vector2D_f GameObject::getPosition()
{
	return pos;
}

void GameObject::checkColision(Vector2D_f pos)
{
	return;
}
