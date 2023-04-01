#pragma once

#include "VulkanKernal.h"

static VulkanKernal::VK Vulkan;

extern "C"
{
	__declspec(dllexport) bool InitializeVulkan(HWND hwnd, HINSTANCE hInstance)
	{
		return Vulkan.Initialize(hwnd, hInstance);
	}

	__declspec(dllexport) void DrawFrame()
	{
		Vulkan.RenderFrame();
	}

	__declspec(dllexport) void CleanUp()
	{
		Vulkan.CleanUp();
	}
}