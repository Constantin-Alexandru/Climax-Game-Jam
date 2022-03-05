#include <SDL.h>
#include <iostream>

#undef main


int main()
{
	SDL_Window* window = NULL;
	SDL_Surface* surface = NULL;

	if (SDL_Init(SDL_INIT_VIDEO) < 0)
	{
		std::cout << "SDL could not be initialized! SDL Error: " << SDL_GetError() << '\n';
		return -1;
	}


	window = SDL_CreateWindow("Climax Game Jam", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 1280, 720, SDL_WINDOW_SHOWN);
	if (window == NULL)
	{
		std::cout << "SDL could not create a window! SDL Error: " << SDL_GetError() << '\n';
		return -1;
	}

	surface = SDL_GetWindowSurface(window);

	SDL_FillRect(surface, NULL, SDL_MapRGB(surface->format, 0xFF, 0xFF, 0xFF));

	SDL_UpdateWindowSurface(window);

	SDL_Delay(10000);


	SDL_DestroyWindow(window);

	SDL_Quit();

	return 0;
}