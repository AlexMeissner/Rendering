#pragma once

namespace VulkanKernal
{
	struct PipelineStateObject
	{
		VkPipelineLayout PipelineLayout = VK_NULL_HANDLE;
		VkPipeline GraphicsPipeline = VK_NULL_HANDLE;
	};

	namespace PipelineState
	{
		// Load from ini file
		PipelineStateObject LoadFromFile(
			const std::filesystem::path& filepath, 
			const VkDevice device, 
			const VkExtent2D& swapChainExtent, 
			const VkDescriptorSetLayout descriptorSetLayout,
			const VkRenderPass renderPass);
	}
}