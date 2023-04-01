#pragma once

struct Vertex;

namespace IO
{
    bool LoadFile(const std::filesystem::path& filepath, std::vector<Vertex>& vertices, std::vector<uint32_t>& indices);
}