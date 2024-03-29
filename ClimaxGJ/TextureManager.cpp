#include "TextureManager.h"


SDL_Texture* TextureManager::LoadTexture(const char* fileName, SDL_Renderer* renderer)
{
	if (fileName == NULL)
		return NULL;

	SDL_Surface* surface = IMG_Load(fileName);

	SDL_Texture* texture = SDL_CreateTextureFromSurface(renderer, surface);

	SDL_FreeSurface(surface);

	return texture;
}