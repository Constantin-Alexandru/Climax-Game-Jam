#include "Engine.h"

std::vector<GameObject*> Engine::gameObjects;
Connection unlinkedConnection;

Engine::Engine() {}

Engine::~Engine() {}

void Engine::init(int x, int y, int width, int height, bool fullscreen)
{
	if (SDL_Init(SDL_INIT_EVERYTHING) != 0)
	{
		std::cout << "Failed to initialise system!\n";
		isRunning = false;
		return;
	}

	int flags = SDL_WINDOW_RESIZABLE;

	if (fullscreen)
	{
		flags |= SDL_WINDOW_FULLSCREEN;
	}

	window = SDL_CreateWindow("ClimaxGJ", x, y, width, height, flags);

	if (window == NULL)
	{
		std::cout << "Failed to create window!\n";
		isRunning = false;
		return;
	}

	std::cout << "Window created!\n";

	renderer = SDL_CreateRenderer(window, -1, 0);

	if (renderer == NULL)
	{
		std::cout << "Failed to create renderer!\n";
		isRunning = false;
		return;
	}

	std::cout << "Renderer created!\n";
	isRunning = true;

	NetworkComponent comp1("assets/square.png", renderer, 10, 20, 30, 30);
	NetworkComponent comp2("assets/square.png", renderer, 200, 644, 30, 30);

	Connection con(NULL, renderer, 0, 0, 0, 0);

}

void Engine::checkCollisionObjects(Vector2D_f mousePos)
{
	for (auto object : gameObjects) {
		object->checkColision(mousePos);
	}
}

void Engine::handleEvents()
{
	SDL_Event event;
	SDL_PollEvent(&event);
	
	switch (event.type)
	{
	case SDL_MOUSEBUTTONUP:
		checkCollisionObjects(Vector2D_f(event.button.x, event.button.y));
		break;
	case SDL_QUIT:
		isRunning = false;
		break;
	}
}

void Engine::update()
{
	for (auto object : gameObjects) {
		object->Update();
	}

}

void Engine::render()
{
	SDL_RenderClear(renderer);

	for (auto object : gameObjects)
	{
		object->Render(); 
	}
		
	SDL_RenderPresent(renderer);
}

void Engine::clean() 
{
	SDL_DestroyWindow(window);
	SDL_DestroyRenderer(renderer);
	SDL_Quit();
	std::cout << "Game exited!\n";
}