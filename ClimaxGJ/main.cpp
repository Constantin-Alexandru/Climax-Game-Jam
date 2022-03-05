#include "Engine.h"

#undef main

int main()
{
	const int targetFPS = 60;
	const int frameDelay = 1000 / targetFPS;

	Uint32 frameStart;
	int frameTime;

	Engine* engine = NULL;

	engine = new Engine();

	engine->init(SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, 1280, 720, false);

	while (engine->running())
	{
		frameStart = SDL_GetTicks();

		engine->handleEvents();
		engine->update();
		engine->render();

		frameTime = SDL_GetTicks() - frameStart;

		if (frameDelay > frameTime)
		{
			SDL_Delay(frameDelay - frameTime);
		}
	}

	engine->clean();


	return 0;
}