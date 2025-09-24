// Copyright Epic Games, Inc. All Rights Reserved.

#include "rpgGameMode.h"
#include "rpgCharacter.h"
#include "UObject/ConstructorHelpers.h"

ArpgGameMode::ArpgGameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPerson/Blueprints/BP_ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
