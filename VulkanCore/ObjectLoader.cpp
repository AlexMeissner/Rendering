#include "pch.h"
#include "ObjectLoader.h"
#include "Vertex.h"

#define TINYOBJLOADER_IMPLEMENTATION

namespace std
{
    void hash_combine(size_t& seed, size_t hash)
    {
        hash += 0x9e3779b9 + (seed << 6) + (seed >> 2);
        seed ^= hash;
    }

    size_t hashV(const DirectX::XMFLOAT2& v)
    {
        size_t seed = 0;
        std::hash<float> hasher;
        hash_combine(seed, hasher(v.x));
        hash_combine(seed, hasher(v.y));
        return seed;
    }

    size_t hashV(const DirectX::XMFLOAT3& v)
    {
        size_t seed = 0;
        std::hash<float> hasher;
        hash_combine(seed, hasher(v.x));
        hash_combine(seed, hasher(v.y));
        hash_combine(seed, hasher(v.z));
        return seed;
    }

    template<> struct hash<Vertex>
    {
        size_t operator()(Vertex const& vertex) const
        {
            return ((hashV(vertex.pos) ^ (hashV(vertex.color) << 1)) >> 1) ^ (hashV(vertex.texCoord) << 1);
            return 0;
        }
    };
}

namespace IO
{
    bool LoadFile(const std::filesystem::path& filepath, std::vector<Vertex>& vertices, std::vector<uint32_t>& indices)
    {
        tinyobj::attrib_t attrib;
        std::vector<tinyobj::shape_t> shapes;
        std::vector<tinyobj::material_t> materials;
        std::string warn, err;

        if (!tinyobj::LoadObj(&attrib, &shapes, &materials, &warn, &err, filepath.string().c_str()))
        {
            return false;
        }

        std::unordered_map<Vertex, uint32_t> uniqueVertices{};

        for (const auto& shape : shapes) {
            for (const auto& index : shape.mesh.indices) {
                Vertex vertex{};

                vertex.pos = {
                    attrib.vertices[3 * index.vertex_index + 0],
                    attrib.vertices[3 * index.vertex_index + 1],
                    attrib.vertices[3 * index.vertex_index + 2]
                };

                vertex.texCoord = {
                    attrib.texcoords[2 * index.texcoord_index + 0],
                    1.0f - attrib.texcoords[2 * index.texcoord_index + 1]
                };

                vertex.color = { 1.0f, 1.0f, 1.0f };

                if (uniqueVertices.count(vertex) == 0) {
                    uniqueVertices[vertex] = static_cast<uint32_t>(vertices.size());
                    vertices.push_back(vertex);
                }

                indices.push_back(uniqueVertices[vertex]);
            }
        }

        return true;
    }
}