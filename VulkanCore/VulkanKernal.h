#pragma once

#include "Vertex.h"
#include "PipelineState.h"

namespace VulkanKernal
{
	class VK
	{
	public:
		bool Initialize(HWND hwnd, HINSTANCE hInstance);
		void CleanUp();
		void RenderFrame();

	private:
		VkCommandBuffer BeginSingleTimeCommands() const;
		void CleanupSwapChain();
		void CopyBuffer(VkBuffer srcBuffer, VkBuffer dstBuffer, VkDeviceSize size);
		void CopyBufferToImage(VkBuffer buffer, VkImage image, uint32_t width, uint32_t height);
		void CreateBuffer(VkDeviceSize size, VkBufferUsageFlags usage, VkMemoryPropertyFlags properties, VkBuffer& buffer, VkDeviceMemory& bufferMemory);
		void CreateColorResources();
		void CreateCommandBuffers();
		void CreateCommandPool();
		void CreateDepthResources();
		void CreateDescriptorPool();
		void CreateDescriptorSetLayout();
		void CreateDescriptorSets();
		void CreateFramebuffers();
		void CreateImage(uint32_t width, uint32_t height, uint32_t mipLevels, VkSampleCountFlagBits numSamples, VkFormat format, VkImageTiling tiling, VkImageUsageFlags usage, VkMemoryPropertyFlags properties, VkImage& image, VkDeviceMemory& imageMemory) const;
		void CreateIndexBuffer();
		void CreateLogicalDevice();
		void GenerateMipmaps(VkImage image, VkFormat imageFormat, int32_t texWidth, int32_t texHeight, uint32_t mipLevels);
		void CreateRenderPass();
		VkShaderModule CreateShaderModule(const std::vector<char>& code) const;
		bool CreateSurface(const HWND windowHandle, const HINSTANCE hInstance);
		void CreateSwapChain(const HWND windowHandle);
		void CreateSyncObjects();
		void CreateTextureImage();
		void CreateTextureImageView();
		void CreateTextureSampler();
		VkImageView CreateImageView(VkImage image, VkFormat format, VkImageAspectFlags aspectFlags, uint32_t mipLevels) const;
		void CreateImageViews();
		void CreateUniformBuffers();
		void CreateVertexBuffer();
		void EndSingleTimeCommands(VkCommandBuffer commandBuffer) const;
		VkFormat FindDepthFormat() const;
		uint32_t FindMemoryType(uint32_t typeFilter, VkMemoryPropertyFlags properties) const;
		VkFormat FindSupportedFormat(const std::vector<VkFormat>& candidates, VkImageTiling tiling, VkFormatFeatureFlags features) const;
		VkSampleCountFlagBits GetMaxUsableSampleCount() const;
		bool IsDeviceSuitable(const VkPhysicalDevice device, const VkSurfaceKHR surface) const;
		void RecordCommandBuffer(VkCommandBuffer commandBuffer, uint32_t imageIndex);
		void RecreateSwapChain();
		void SelectPhysicalDevice();
		void TransitionImageLayout(VkImage image, VkFormat format, VkImageLayout oldLayout, VkImageLayout newLayout, uint32_t mipLevels);
		void UpdateUniformBuffer(uint32_t currentImage);

	private:
		VkInstance Instance = VK_NULL_HANDLE;
		VkDebugUtilsMessengerEXT DebugMessenger = VK_NULL_HANDLE;
		VkSurfaceKHR Surface = VK_NULL_HANDLE;
		VkPhysicalDevice PhysicalDevice = VK_NULL_HANDLE;
		VkSampleCountFlagBits MSAASamples = VK_SAMPLE_COUNT_1_BIT;
		VkDevice Device = VK_NULL_HANDLE;
		VkQueue GraphicsQueue = VK_NULL_HANDLE;
		VkQueue PresentQueue = VK_NULL_HANDLE;
		VkSwapchainKHR SwapChain = VK_NULL_HANDLE;
		std::vector<VkImage> SwapChainImages;
		VkFormat SwapChainImageFormat;
		VkExtent2D SwapChainExtent;
		std::vector<VkImageView> SwapChainImageViews;
		std::vector<VkFramebuffer> SwapChainFramebuffers;
		VkRenderPass RenderPass = VK_NULL_HANDLE;
		VkDescriptorSetLayout DescriptorSetLayout = VK_NULL_HANDLE;
		VkCommandPool CommandPool = VK_NULL_HANDLE;
		VkImage ColorImage = VK_NULL_HANDLE;
		VkDeviceMemory ColorImageMemory = VK_NULL_HANDLE;
		VkImageView ColorImageView = VK_NULL_HANDLE;
		VkImage DepthImage = VK_NULL_HANDLE;
		VkDeviceMemory DepthImageMemory = VK_NULL_HANDLE;
		VkImageView DepthImageView = VK_NULL_HANDLE;
		uint32_t MipLevels = 0;
		VkImage TextureImage = VK_NULL_HANDLE;
		VkDeviceMemory TextureImageMemory = VK_NULL_HANDLE;
		VkImageView TextureImageView = VK_NULL_HANDLE;
		VkSampler TextureSampler = VK_NULL_HANDLE;
		std::vector<Vertex> Vertices;
		std::vector<uint32_t> Indices;
		VkBuffer VertexBuffer = VK_NULL_HANDLE;
		VkDeviceMemory VertexBufferMemory = VK_NULL_HANDLE;
		VkBuffer IndexBuffer = VK_NULL_HANDLE;
		VkDeviceMemory IndexBufferMemory = VK_NULL_HANDLE;
		std::vector<VkBuffer> UniformBuffers;
		std::vector<VkDeviceMemory> UniformBuffersMemory;
		VkDescriptorPool DescriptorPool = VK_NULL_HANDLE;
		std::vector<VkDescriptorSet> DescriptorSets;
		std::vector<VkCommandBuffer> CommandBuffers;
		std::vector<VkSemaphore> ImageAvailableSemaphores;
		std::vector<VkSemaphore> RenderFinishedSemaphores;
		std::vector<VkFence> InFlightFences;
		uint32_t CurrentFrame = 0;
		bool FramebufferResized = false;
		PipelineStateObject PSO;

		HWND Hwnd;
	};
}